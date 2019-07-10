import React from 'react'
import { Spinner } from 'reactstrap';

export default props => (
    <div className={`has-background-success in-progress`}>   
            EM ANDAMENTO <Spinner type="grow" color="danger" size="sm" style={{ marginLeft: '5px',width: '1.5rem', height: '1.5rem' }} />            
    </div>
)