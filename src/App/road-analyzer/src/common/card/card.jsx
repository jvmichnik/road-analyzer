import React from 'react'
import { Link } from "react-router-dom";

import Conteudocard from './conteudocard'
import LabelFinalizado from './labelFinalizado'
import LabelProgresso from './labelProgresso'
import './card.css'

export default function(props){

    const startDate = props.start ? new Date(props.start).toLocaleString('pt-BR') : "";
    const endDate = props.end ? new Date(props.end).toLocaleString('pt-BR') : "";

    return <Link to={`/detail/${props.id}`} className={props.className}>
        <article className="media">
            <div className="media-content columns" style={{margin: 0}}>
                <Conteudocard size="7">
                    <div>
                        <p>
                            <strong>{props.title}</strong> 
                            <br/>
                            {props.description}
                        </p>
                    </div>
                </Conteudocard>
                <Conteudocard size="2">
                    <div style={{textAlign: 'center', width: '100%'}}>
                        <span className='label-conteudo'>INICIADO</span> 
                        <br/>
                        <span className='value-conteudo'>{startDate}</span>
                    </div>
                </Conteudocard>
                <Conteudocard size="3">
                    {endDate ? <LabelFinalizado color='label-conteudo' value={endDate}/> : <LabelProgresso/> }
                </Conteudocard>
            </div>
        </article>
    </Link>
}