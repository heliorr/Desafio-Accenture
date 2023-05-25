<template>
    <form class="delay-150">
        <label for="cnpjCpf" class="block mb-1 text-sm font-medium text-gray-900 dark:text-white">
            CNPJ/CPF:
            <input v-model="cnpj" id="cnpjCpf" @change="checkCpf" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <div class="flex justify-between">
          <label :class="this.disableRgeDate"  for="rg">
            RG:
            <input v-model="RG" id="rg" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
          </label>
          <label :class="this.disableRgeDate" for="dateBirth">
            Data de Nascimento:
            <input type="date" v-model="date" id="dateBirth" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
          </label>
        </div>
        
        <label for="name">
            Nome:
            <input v-model="name" id="name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="email">
            E-mail:
            <input v-model="email" id="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="cep">
            CEP:
            <input v-model="cep" id="cep" @change="checkCep" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="district">
            Bairro:
            <input v-model="data.bairro" id="district" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <div class="flex justify-between">
          <label for="street">
            Rua:
            <input v-model="data.logradouro" id="street" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
          </label>
          <label for="residence">
            Numero:
            <input v-model="number" id="residence" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
          </label>
        </div>
        <div class="flex justify-between">
          <label for="city">
            Cidade:
            <input v-model="data.cidade" id="city" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
          </label>
          <label for="state">
            Estado:
            <input v-model="data.uf" id="state" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
          </label>
        </div>
        <button @click="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Cadastrar</button>
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
      date: '2000-01-01',
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
      companys: [],
    }
  },
  create(){
    fetch("https://localhost:7189/api/company/GetAll")
      .then(response => response.json())
      .then(data => (this.companys = data));
      console.log(this.companys)
  },
  methods:{
      checkCep: async function (){
          if(this.cep.length != 8){
            alert('CEP Invalido!');
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
      calculaIdade(nascimento){
        const hoje = new Date();
        return Math.floor(Math.ceil(Math.abs(nascimento - hoje.getTime()) / (1000 * 3600 * 24)) / 365.25);
      },
      async submitFetch(){
          const _data = {
            cnpjCpf: this.cnpj,
            rg: this.RG,
            dateBirth: this.date,
            name: this.name,
            email: this.email,
            cep: this.cep,
            bairro: this.data.bairro,
            logradouro: this.data.logradouro,
            cidade: this.data.cidade,
            uf: this.data.uf,
            numberHouse: this.number
          };
        await fetch("https://localhost:7189/api/Suplier", {
          method: "POST",
          headers: {"Content-type": "application/json; charset=UTF-8"},
          body: JSON.stringify(_data),
          });
        this.$router.push('/suplier');
      },
      submit(e){
          e.preventDefault()
          if(this.data.uf == "PR" && this.cnpj.length == 11){
            const idade = this.calculaIdade(Date.parse(this.date));
              if(idade < 18){
                alert('Cadastro negado para menores de idade no estado do Paraná')
              }else{
                this.submitFetch();
              }
          }else{
            this.submitFetch();
          }
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