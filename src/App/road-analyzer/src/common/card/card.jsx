import React from 'react'
import { Link } from "react-router-dom";

import Conteudocard from './conteudocard'
import LabelFinalizado from './labelFinalizado'
import LabelProgresso from './labelProgresso'
import './card.css'

export default props => (
    <Link to='/detail' className={`box box-${props.end ? "down" : "up"}`}>
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
                        <span className='value-conteudo'>{props.start}</span>
                    </div>
                </Conteudocard>
                <Conteudocard size="3">
                    {props.end ? <LabelFinalizado color='label-conteudo' value={props.end}/> : <LabelProgresso/> }
                </Conteudocard>
            </div>
        </article>
    </Link>
)