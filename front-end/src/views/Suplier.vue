<template>
  <main class="content">
    <router-link to="/suplier/cadastro"><button class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800 mb-5">Cadastrar Fornecedor</button></router-link>
    <input v-model="FilterName" id="filter" @change="checkName" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Pesquise Pelo Nome:">
    <input v-model="FilterCnpj" id="filter" @change="checkCnpj" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-1 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Pesquise Pelo CNPJ/CPF:">
    <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400">
        <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
            <tr>
                <th scope="col" class="px-6 py-3">Cod.</th>
                <th scope="col" class="px-6 py-3">Nome</th>
                <th scope="col" class="px-6 py-3">Endereço</th>
                <th scope="col" class="px-6 py-3">CNPJ/CPF</th>
                <th scope="col" class="px-6 py-3">RG</th>
                <th scope="col" class="px-6 py-3">Contato</th>
                <th scope="col" class="px-6 py-3">Ações</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="suplier in supliersFilter" :key="suplier.id" class="bg-white border-b dark:bg-gray-800 dark:border-gray-700">
                <td scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                  {{ suplier.id }}
                </td>
                <td scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                  {{ suplier.name }}
                </td>
                <td scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                 {{ suplier.logradouro }}, {{ suplier.bairro }}, {{ suplier.numberHouse }}, {{ suplier.cidade }}-{{ suplier.uf }}
                </td>
                <td class="px-6 py-4">
                  {{ suplier.cnpjCpf.length == 11 ? suplier.cnpjCpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4") : suplier.cnpjCpf.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1 $2 $3/$4-$5") }}
                </td>
                <td class="px-6 py-4">
                  {{ suplier.rg }}
                </td>
                <td class="px-6 py-4">
                  {{ suplier.email }}
                </td>
                <td class="flex justify-between px-6 py-4">
                  <button class="w-30 bg-blue-500 hover:bg-blue-700 text-white font-bold py-0 px-4 rounded">Detalhe</button>
                  <button class="w-30 bg-red-500 hover:bg-red-700 text-white font-bold py-0 px-4 rounded">Deletar</button>
                </td>
            </tr>
        </tbody>
    </table>
  </main>
</template>

<script>

export default {
  name: 'SuplierMain',
    data() {
      return {
        supliers: [],
        supliersFilter: [],
        FilterName: '',
        FilterCnpj: '',
      };
    },
    created(){
      fetch("https://localhost:7189/api/suplier/GetAll")
        .then(response => response.json())
        .then(data => {
            this.supliers = data.data;
            this.supliersFilter = data.data;
          });
          
    },
    methods: {
      checkName: function () {
        if(this.FilterName.length > 0){
          this.supliersFilter = this.supliers.filter(c => c.name.includes(this.FilterName));
        }else{
          this.supliersFilter = this.supliers;
        }
      },
      checkCnpj: function () {
        if(this.FilterCnpj.length > 10){
          this.supliersFilter = this.supliers.filter(c => c.cnpjCpf === this.FilterCnpj);
        }else{
          this.supliersFilter = this.supliers;
        }
      },
    },
    components: {
    }
}
</script>

<style>
.content {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
</style>
