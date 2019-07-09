import React from 'react'

export default props => (
    <div className={`column is-${props.size}`}>
        {props.children}
    </div>
)