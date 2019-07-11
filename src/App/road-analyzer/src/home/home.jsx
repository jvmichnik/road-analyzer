import React, { Component } from 'react'
import { TransitionGroup, CSSTransition  } from 'react-transition-group'

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
        const list = this.props.trechos
        const adicionado = this.props.adicionado
        if(list.length === 0){
            return  <Line>
                        <Column size="12">
                            <div className="notification">
                                Nenhum levantamento realizado.
                            </div>
                        </Column>
                    </Line>
        }

        return list.map((item, index) => {
            const className = `box box-${item.end ? "down" : "up"}`

            return <CSSTransition key={item.id }
                    classNames={`${adicionado && item.id === adicionado.id ? "slide" : ""}`}
                    timeout={{ enter: 50000, exit: 30000 }}>
                        <Line>
                            <Column size="12">
                                <Card id={item.id} title={item.name} description={item.description} start={item.start} end={item.end} className={className}/>
                            </Column>
                        </Line>
                    </CSSTransition>
        })
    }

    render(){
        
        return (
            <div className="wrapper">
                <Header/>
                <Painel/>
                <TransitionGroup>
                    {this.renderRows()}                    
                </TransitionGroup >
                <Footer />
            </div>
        )
    }
}
const mapStateToProps = state => ({trechos: state.home.trechos, adicionado: state.home.adicionado})
const mapDispatchToProps = dispatch => bindActionCreators({getTrechos}, dispatch)
export default connect(mapStateToProps, mapDispatchToProps)(Home)