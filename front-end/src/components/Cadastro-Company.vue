<template>
    <form @change="checkForm">
        <label for="cnpj">
            CNPJ:
            <input type="text" name="cnpj" id="cnpj" key="cnpj">
        </label>
        <label for="company">
            Nome Fantasia:
            <input type="text" name="company" id="company" key="company">
        </label>
        <label for="cep">
            CEP:
            <input v-model="cep">
        </label>
        <label for="district">
            Bairro:
            <input type="text" v-model="data.bairro">
        </label>
        <label for="street">
            Rua:
            <input type="text" v-model="data.logradouro">
        </label>
        <label for="city">
            Cidade:
            <input type="text" v-model="data.cidade">
        </label>
        <label for="state">
            Estado:
            <input type="text" v-model="data.uf">
        </label>
        <label for="residence">
            Numero:
            <input type="text" name="residence" id="residence" key="residence">
        </label>
        <button @click="submit">Cadastrar</button>
    </form>
</template>

<script>

export default {
  name: 'App',
  data() {
    return {
      cep: '',
      data: {
        bairro: '',
        logradouro: '',
        cidade: '',
        uf: '',
      },
    }
  },
  methods:{
      checkForm: async function (){
          if(this.cep.length != 8){
            console.log('invalido1')
          }else{
              try {
                const url = `http://cep.la/${this.cep}`;
                const xhr = new XMLHttpRequest();
                let address = {};
                xhr.open ("GET", url, true);
                xhr.setRequestHeader ("Accept", "application/json");
                xhr.onload = () => {
                    address = JSON.parse(xhr.response);
                    this.data = address;
                };
                xhr.send (null);
              }catch(e){
                console.log(e)
              }
          }
      },
      submit(e){
          e.preventDefault()
          console.log(this.data.address.uf);
      }
  }
}
</script>

<style>
form {
  display: flex;
  flex-direction: column;
  width: 50%;
}

form label {
  display: flex;
  flex-direction: column;
  margin-bottom: 2%;
}
</style>