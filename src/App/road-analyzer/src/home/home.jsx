import React, { Component } from 'react';

import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { getTrechos } from './homeActions'

import Header from '../common/header/header'
import Painel from '../common/painel/painel'
import Line from '../common/columns/line'
import Column from '../common/columns/column'
import Card from '../common/card/card'
import Footer from '../common/footer/footer'

class Home extends Component {

    componentWillMount() {
        this.props.getTrechos()
    }

    renderRows(){
        const list = this.props.trechos || []

        return list.map((item, index) => {
            const startDate = item.start ? new Date(item.start).toLocaleString('pt-BR') : "";
            const endDate = item.end ? new Date(item.end).toLocaleString('pt-BR') : "";

            return  <Line key={index}>
                        <Column size="12">
                            <Card title={item.name} description={item.description} start={startDate} end={endDate}/>
                        </Column>
                    </Line>
        })
    }

    render(){
        return (
            <div className="wrapper">
                <Header/>
                <Painel/>
                    {this.renderRows()}
                <Footer />
            </div>
        )
    }
}
const mapStateToProps = state => ({trechos: state.home.trechos})
const mapDispatchToProps = dispatch => bindActionCreators({getTrechos}, dispatch)
export default connect(mapStateToProps, mapDispatchToProps)(Home)