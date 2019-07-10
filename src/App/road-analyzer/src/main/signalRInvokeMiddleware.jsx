import React from 'react';
import * as SignalR from '@aspnet/signalr';
import { toast } from 'react-toastify';

import { MessageLevantamentoIniciado } from '../common/msg/messages'

  const connection = new SignalR.HubConnectionBuilder()
  .withUrl('http://localhost:8083/notificationhub')
  .build();

export function signalRRegisterCommands(store, callback) {
    connection.on('LevantamentoStarted', data => {
        toast.info(<MessageLevantamentoIniciado/>, {
            position: "bottom-left",
            autoClose: 5000,
            hideProgressBar: true,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: false
            });
        store.dispatch({ type: 'LEVANTAMENTO_STARTED', payload: data})
    })
    connection.on('LevantamentoConcluded', data => {
        store.dispatch({ type: 'LEVANTAMENTO_CONCLUDED', payload: data})
    })
    connection.start().then(callback());

}