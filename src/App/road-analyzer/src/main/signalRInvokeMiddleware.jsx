import React from 'react';
import * as SignalR from '@aspnet/signalr';
import { toast } from 'react-toastify';

import { MessageLevantamentoIniciado } from '../common/msg/messages'

  const connection = new SignalR.HubConnectionBuilder()
  //.withUrl('http://ec2-18-228-156-207.sa-east-1.compute.amazonaws.com:8083/notificationhub')
  .withUrl('http://localhost:8083/notificationhub')
  .build();

export default function signalRInvokeMiddleware(store) {
    return (next) => async (action) => {
        switch (action.type) {
            case "GROUP_JOINED": 
                connection.invoke('JoinGroup',action.payload);
                break;   
            case "GROUP_LEAVED": 
                connection.invoke('LeaveGroup',action.payload);
                break;   
            default:
                break;
        }
     
        return next(action);
    }
}

export function signalRRegisterCommands(store, callback) {
    connection.on('LevantamentoStarted', data => {
        toast.info(<MessageLevantamentoIniciado id={data.id}/>, {
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
    connection.on('LogSended', data => {
        store.dispatch({ type: 'LOG_SENDED', payload: data})
    })
    connection.start().then((result) => {
        callback()
    })

}