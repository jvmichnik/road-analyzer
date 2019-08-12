import React, { Component } from 'react';
import { TextInput, Text, View, Button } from 'react-native';

const instructions = Platform.select({
  ios: 'Press Cmd+R to reload,\n' + 'Cmd+D or shake for dev menu',
  android: 'Double tap R on your keyboard to reload,\n' + 'Shake or press menu button for dev menu',
});

export default class FormLevantamento extends Component {

    constructor(props) {
        super(props);
        this.state = {
          nome: '',
          descricao: ''
        };
      }

    onStart(){

        fetch('http://ec2-18-228-156-207.sa-east-1.compute.amazonaws.com:8080/api/l/levantamentos', {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: this.state.nome,
                description: this.state.descricao,
                start: '2019-08-09T21:18:17.41'
            })
        });
    }
  render() {


    return (
        <View style={{ 
            paddingTop: 20,
            padding: 40, 
        }}>
            <Text>
                {this.state.nome}
            </Text>
          <TextInput
            style={{ 
                height: 40, 
                borderColor: 'gray', 
                borderWidth: 1,
                marginBottom: 10
            }}
            onChangeText={text => this.setState({ nome: text })}
            placeholder='Nome'
          />
          <TextInput
            style={{ 
                height: 40, 
                borderColor: 'gray', 
                borderWidth: 1,
            }}
            placeholder='Descrição'
            onChangeText={text => this.setState({ descricao: text })}
          />
        <Button           
            onPress={this.onPressStart}
            title="Iniciar Levantamento"
            color="blue"            
          />
        </View>
    );
  }
}