import React from 'react'
import { ToastContainer,Slide } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Spinner } from 'reactstrap';

export function MessageLevantamentoIniciado(props){
    return <div>
                <Spinner type="grow" color="light" size="sm" style={{ marginRight: '5px',width: '1.5rem', height: '1.5rem' }} />
                Um novo levantamento foi iniciado! <a href='/' className='link-acompanhar'>Acompanhar</a>
                
            </div>
}

export function MessageContainer(props){
    return <ToastContainer 
    transition={Slide}/>
}