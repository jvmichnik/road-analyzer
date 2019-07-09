import React from 'react'
import { Link } from "react-router-dom";

import Conteudocard from './conteudocard'
import LabelData from './labelData'
import LabelProgresso from './labelProgresso'
import './card.css'

export default props => (
    <Link to='/detail' className="box">
        <article className="media">
            <div className="media-content columns">
                <Conteudocard size="8">
                    <p>
                        <strong>{props.title}</strong> 
                        <br/>
                        {props.description}
                    </p>
                </Conteudocard>
                <Conteudocard size="2">
                    <LabelData color='has-background-link' label='Iniciado' value={props.start}/>
                </Conteudocard>
                <Conteudocard size="2">
                    {props.end ? <LabelData color='has-background-grey-darker' label='Finalizado' value={props.end}/> : <LabelProgresso/> }
                </Conteudocard>
            </div>
        </article>
    </Link>
)