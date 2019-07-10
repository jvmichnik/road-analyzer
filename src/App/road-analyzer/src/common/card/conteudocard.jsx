import React from 'react'

export default props => (
    // , borderRadius: '75px 0px 75px 0px', backgroundColor: 'black'
    <div className={`column is-${props.size}`} style={{display: 'flex', alignItems: 'center', padding: 0 }}>
        {props.children}
    </div>
)