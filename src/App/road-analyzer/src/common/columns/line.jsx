import React, { Component } from 'react'

class Line extends Component {

    render(){
        return (
            <div className="container">
                <div className="columns">
                    {this.props.children}
                </div>
            </div>
        )
    }
}
export default Line;