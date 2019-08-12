import React, { Component } from 'react';
import { Platform, Text, View, Button } from 'react-native';

import FormLevantamento from './FormLevantamento'

const instructions = Platform.select({
  ios: 'Press Cmd+R to reload,\n' + 'Cmd+D or shake for dev menu',
  android: 'Double tap R on your keyboard to reload,\n' + 'Shake or press menu button for dev menu',
});

export default class CardBottom extends Component {
  constructor(props) {
    super(props);
    this.state = {
      sizeArea: 50,
      opened: false
    };
  }

  onPressStart = () => {
    this.setState({
      sizeArea: this.state.opened ? 50 : 400,
      opened: !this.state.opened
    });
  }

  render() {
    return (
        <View style={{ height: this.state.sizeArea, backgroundColor: 'white' }}>
          <Button           
            onPress={this.onPressStart}
            title="Levantamento"
            color="black"            
          />
          <FormLevantamento/>
        </View>
    );
  }
}