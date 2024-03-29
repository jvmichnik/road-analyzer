﻿using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Levantamento.Domain.Core.Interfaces;
using Levantamento.Domain.Core.Notifications;
using Levantamento.Infrastructure.Sql.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Infrastructure.Sql.Context
{
    public class LevantamentoContext : DbContext, IUnitOfWork
    {
        public DbSet<Domain.AggregatesModel.LevantamentoAggregate.Levantamentos> Levantamento { get; set; }
        public DbSet<Log> Log { get; set; }

        private readonly IMediator _mediator;
        private IDbContextTransaction _currentTransaction;
        private readonly DomainNotificationHandler _notifications;

        private LevantamentoContext(DbContextOptions<LevantamentoContext> options) : base(options) { }
        public LevantamentoContext(DbContextOptions<LevantamentoContext> options, IMediator mediator, INotificationHandler<DomainNotification> notifications) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _notifications = (DomainNotificationHandler)notifications ?? throw new ArgumentNullException(nameof(notifications));
        }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LevantamentoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LogEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if(!_notifications.HasNotifications())
            {
                await _mediator.DispatchDomainEventsAsync(this);

                var result = await base.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
    
}
