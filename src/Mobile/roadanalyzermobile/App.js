import React, { Component } from 'react';
import MapView, { Marker } from 'react-native-maps';
import { Platform, StyleSheet, Text, View, Button } from 'react-native';

import CardBottom from './components/CardBottom';

const instructions = Platform.select({
  ios: 'Press Cmd+R to reload,\n' + 'Cmd+D or shake for dev menu',
  android: 'Double tap R on your keyboard to reload,\n' + 'Shake or press menu button for dev menu',
});

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      titleText: "Road Analyzer"
    };
  }

  render() {
    return (
      <View style={{flex: 1}}>
        <View style={{ height: 50, backgroundColor: 'white' }}>
          <Text style={styles.titleText}>
            {this.state.titleText}
          </Text>
        </View>
        <MapView
            style={{flex: 1}}
            initialRegion={{
              latitude: -15.793767,
              longitude: -47.882667,
              latitudeDelta: 0.0922,
              longitudeDelta: 0.0421,
            }}
          >          
          </MapView>
        <CardBottom />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  titleText: {
    fontSize: 20,
    fontWeight: 'bold',
    textAlign: 'center',
    marginTop: 20
  }
});
