import * as SignalR from '@aspnet/signalr';

  const connection = new SignalR.HubConnectionBuilder()
  .withUrl('http://localhost:8083/notificationhub')
  .build();

export function signalRRegisterCommands(store, callback) {
    connection.on('LevantamentoStarted', data => {
        store.dispatch({ type: 'LEVANTAMENTO_STARTED', payload: data})
    })
    connection.on('LevantamentoConcluded', data => {
        store.dispatch({ type: 'LEVANTAMENTO_CONCLUDED', payload: data})
    })
    connection.start().then(callback());

}