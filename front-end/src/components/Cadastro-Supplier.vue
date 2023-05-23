<template>
    <form>
        <label for="cnpjCpf">
            CNPJ/CPF:
            <input v-model="cnpj" id="cnpjCpf" @change="checkCpf">
        </label>
        <label :class="this.disableRgeDate"  for="rg">
            RG:
            <input v-model="RG" id="rg">
        </label>
        <label :class="this.disableRgeDate" for="dateBirth">
            Data de Nascimento:
            <input v-model="date" id="dateBirth">
        </label>
        <label for="name">
            Nome:
            <input v-model="name" id="name">
        </label>
        <label for="email">
            E-mail:
            <input v-model="email" id="email">
        </label>
        <label for="cep">
            CEP:
            <input v-model="cep" id="cep" @change="checkCep">
        </label>
        <label for="district">
            Bairro:
            <input v-model="data.bairro" id="district">
        </label>
        <label for="street">
            Rua:
            <input v-model="data.logradouro" id="street">
        </label>
        <label for="city">
            Cidade:
            <input v-model="data.cidade" id="city">
        </label>
        <label for="state">
            Estado:
            <input v-model="data.uf" id="state">
        </label>
        <label for="residence">
            Numero:
            <input v-model="number" id="residence">
        </label>
        <button @click="submit">Cadastrar</button>
    </form>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      cnpj: '',
      disableRgeDate: 'hide',
      RG: '',
      date: '',
      name: '',
      cep: '',
      number: '',
      email: '',
      data: {
        bairro: '',
        logradouro: '',
        cidade: '',
        uf: '',
      },
    }
  },
  methods:{
      checkCep: async function (){
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
      checkCpf: async function (){
          if(this.cnpj.length == 11){
            this.disableRgeDate = '';
          }else{
            this.disableRgeDate = 'hide';
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

.hide {
    display: none;
}

form label {
  display: flex;
  flex-direction: column;
  margin-bottom: 2%;
}
</style>