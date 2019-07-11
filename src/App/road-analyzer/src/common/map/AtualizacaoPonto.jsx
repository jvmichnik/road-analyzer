import * as React from 'react';
import { loadModules } from '@esri/react-arcgis';
 
export default class AtualizacaoPonto extends React.Component {
 
    render() {
        this.renderGraphic()
        return null;
    }
 
    componentWillMount() {
        this.renderGraphic()
    }
    renderGraphic(){
        loadModules(['esri/Graphic']).then(([ Graphic ]) => {
            this.props.view.graphics.removeAll()
            // Create a polygon geometry
            var point = {
                type: "point", // autocasts as new Point()
                longitude: this.props.long,
                latitude: this.props.lat
              };
      
              // Create a symbol for drawing the point
              var markerSymbol = {
                type: "simple-marker", // autocasts as new SimpleMarkerSymbol()
                color: [35, 209, 96],
                outline: {
                  // autocasts as new SimpleLineSymbol()
                  color: [255, 255, 255],
                  width: 2
                }
              };
              
              var polyline = {
                type: "polyline", // autocasts as new Polyline()
                paths: [this.props.logs]
              };
      
              // Create a symbol for drawing the line
              var lineSymbol = {
                type: "simple-line", // autocasts as SimpleLineSymbol()
                color: [35, 209, 96],
                width: 4
              };
            // Add the geometry and symbol to a new graphic
            const lineGraphic = new Graphic({
                geometry: polyline,
                symbol: lineSymbol
            });
            const graphic = new Graphic({
                geometry: point,
                symbol: markerSymbol
            });

            
            const view = this.props.view
            view.center = [this.props.long,this.props.lat] //Centralizar ponto
            view.graphics.addMany([graphic,lineGraphic]);
        }).catch((err) => console.error(err));
    }
}