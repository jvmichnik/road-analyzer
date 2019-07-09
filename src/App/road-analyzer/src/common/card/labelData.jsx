import React from 'react'

export default props => (
    <div style={{textAlign: 'center', width: '100%'}}>
        <span className={`label-conteudo ${props.color}`}>{props.label}</span> 
        <br/>
        <span className='value-conteudo'>{props.value}</span>
    </div>
)