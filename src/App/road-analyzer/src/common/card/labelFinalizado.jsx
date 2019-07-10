import React from 'react'

export default props => (
    <div className='has-background-dark concluded' style={{textAlign: 'center', width: '100%'}}>
        <span className=''>CONCLUIDO</span> 
        <span className='value-conteudo'>{props.value}</span>
    </div>
)