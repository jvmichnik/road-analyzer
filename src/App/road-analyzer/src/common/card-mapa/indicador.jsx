import React from 'react'
import './indicador.css'
import Line from '../columns/line'
import Column from '../columns/column'

export default function(props) {
        const rate = props.rate ? props.rate.toFixed(1) : "0";
        const speed = props.speed ? props.speed : "0";

        return <div className='card-indicador'>
            <Line>
                <Column size='5'>
                    <a href="/" className="navbar-item">
                        <h1 className="title title-header is-4">Road Analyzer</h1>
                    </a>
                </Column>
                <Column size='3'>
                    <div className='indicador-status'>
                        <p className='value'>{speed}</p>
                        <p className='label'>Velocidade</p>
                    </div>
                </Column>
                <Column size='3'>
                    <div className='indicador-status'>
                        <p className='value'>{rate}</p>
                        <p className='label'>Rate</p>
                    </div>
                </Column>
                <Column size='1'>
                </Column>
            </Line>
        </div>
}