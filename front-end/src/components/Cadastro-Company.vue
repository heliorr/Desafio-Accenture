<template>
    <form class="delay-150">
        <label for="cnpj" class="block mb-1 text-sm font-medium text-gray-900 dark:text-white">
            CNPJ:
            <input v-model="cnpj" id="cnpj" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="company" class="block mb-1 text-sm font-medium text-gray-900 dark:text-white">
            Nome Fantasia:
            <input v-model="name" id="company" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="cep" class="block mb-1 text-sm font-medium text-gray-900 dark:text-white">
            CEP:
            <input v-model="cep" id="cep" @change="checkCep" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="district" class="block mb-1 text-sm font-medium text-gray-900 dark:text-white">
            Bairro:
            <input v-model="data.bairro" id="district" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="street" class="block mb-1 text-sm font-medium text-gray-900 dark:text-white">
            Rua:
            <input v-model="data.logradouro" id="street" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="city" class="block mb-1 text-sm font-medium text-gray-900 dark:text-white">
            Cidade:
            <input v-model="data.cidade" id="city" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="state" class="block mb-1 text-sm font-medium text-gray-900 dark:text-white">
            Estado:
            <input v-model="data.uf" id="state" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <label for="residence" class="block mb-1 text-sm font-medium text-gray-900 dark:text-white">
            Numero:
            <input v-model="number" id="residence" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        </label>
        <button @click="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Cadastrar</button>
    </form>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      cnpj: '',
      name: '',
      number: '',
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
      async submit(e){
        e.preventDefault();
        const _data = {
            cnpj: this.cnpj,
            name: this.name,
            cep: this.cep,
            bairro: this.data.bairro,
            logradouro: this.data.logradouro,
            cidade: this.data.cidade,
            uf: this.data.uf,
            numberHouse: this.number
          };
        await fetch("https://localhost:7189/api/company", {
          method: "POST",
          headers: {"Content-type": "application/json; charset=UTF-8"},
          body: JSON.stringify(_data),
          });
        this.$router.push('/company');
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