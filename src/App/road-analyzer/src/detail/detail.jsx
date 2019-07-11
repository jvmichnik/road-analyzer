import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import { getLogs } from './detailActions'
import { joinGroup, leaveGroup } from '../main/signalRActions'

import Card from '../common/card/card'
import Mapa from '../common/map/mapa'
import Indicador from '../common/card-mapa/indicador'

class Detail extends Component {

    componentDidMount(prevProps) {      
        this.props.getLogs(this.props.match.params.id)  
        this.props.joinGroup(this.props.match.params.id)   
    }
    componentDidUpdate(prevProps) {
        if(prevProps.match.params.id != this.props.match.params.id){
            this.props.getLogs(this.props.match.params.id)  
            this.props.joinGroup(this.props.match.params.id) 
        }
    }
    componentWillUnmount() {
        this.props.leaveGroup(this.props.match.params.id) 
    }
    render(){
        const { logActual, trecho } = this.props.levantamentos[this.props.match.params.id] || { trecho: {}, logActual: { lat: 0, long: 0 } }

        var logs = trecho.logs || []

        const className = `box box-detail`

        const listLogs = logs.map(x => [x.long,x.lat])

        return (
            <div className="wrapper">
                <Card id={trecho.id} title={trecho.name} description={trecho.description} start={trecho.start} end={trecho.end} className={className}/>
                <Indicador speed={logActual.speed} rate={logActual.rate}/>
                <Mapa lat={logActual.lat} long={logActual.long} logs={listLogs}/>
            </div>
        )
    }
}
const mapStateToProps = state => ({ levantamentos: state.detail.levantamentos })
const mapDispatchToProps = dispatch => bindActionCreators({getLogs,joinGroup,leaveGroup}, dispatch)
export default connect(mapStateToProps, mapDispatchToProps)(Detail)