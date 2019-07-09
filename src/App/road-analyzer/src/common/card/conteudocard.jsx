import React from 'react'

export default props => (
    <div className={`column is-${props.size}`} style={{display: 'flex', alignItems: 'center'}}>
        {props.children}
    </div>
)