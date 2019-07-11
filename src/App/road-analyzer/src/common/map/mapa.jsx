import React, { Component } from 'react';
import { Map } from '@esri/react-arcgis';

import AtualizacaoPonto from './AtualizacaoPonto';

class Mapa extends Component {
  
    
    render(){
        return <Map 
                style={{ width: '100vw', height: '100vh' }} 
                className="full-screen-map" 
                mapProperties={{ basemap: 'hybrid' }}
                viewProperties={{
                    center: [this.props.long,this.props.lat],
                    zoom: 17
                }}>
                    <AtualizacaoPonto lat={this.props.lat} long={this.props.long} logs={this.props.logs} />
            </Map>
        // return <Scene  
        //             style={{ width: '100%', height: '500px' }}
        //             mapProperties={{ basemap: 'satellite' }}
        //             viewProperties={{
        //                 center: [-47.882667,-15.793566],
        //                 zoom: 15.7
        //             }}>
        //         </Scene>
    }
}

export default Mapa;