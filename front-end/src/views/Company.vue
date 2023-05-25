<template>
  <main class="content">
    <router-link to="/company/cadastro"><button class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800 mb-5">Cadastrar Empresa</button></router-link>
    <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400">
        <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
            <tr>
                <th scope="col" class="px-6 py-3">Cod.</th>
                <th scope="col" class="px-6 py-3">Nome</th>
                <th scope="col" class="px-6 py-3">Endereço</th>
                <th scope="col" class="px-6 py-3">CNPJ</th>
                <th scope="col" class="px-6 py-3">Fornecedores</th>
                <th scope="col" class="px-6 py-3">Ações</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="company in companys" :key="company.id" class="bg-white border-b dark:bg-gray-800 dark:border-gray-700">
                <td scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                  {{ company.id }}
                </td>
                <td scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                  {{ company.name }}
                </td>
                <td scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                  {{ company.logradouro }}, {{ company.bairro }}, {{ company.numberHouse }}, {{ company.cidade }}-{{ company.uf }}
                </td>
                <td class="px-6 py-4">
                  {{ company.cnpj.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1 $2 $3/$4-$5") }}
                </td>
                <td class="px-6 py-4">t</td>
                <td class="flex flex-row px-2 py-1">
                  <button class="w-40 bg-green-500 hover:bg-green-700 text-white font-bold py-0 px-4 rounded">Adicionar Fornecedor</button>
                  <div class="flex flex-col ml-1">
                    <button class="w-40 bg-blue-500 hover:bg-blue-700 text-white font-bold py-0 px-4 rounded">Detalhe</button>
                    <button :id="company.id" @click="deleteCompany" class="w-40 bg-red-500 hover:bg-red-700 text-white font-bold py-0 px-4 rounded">Deletar</button>
                  </div>
                  
                </td>
            </tr>
        </tbody>
    </table>
  </main>
</template>

<script>

export default {
  name: 'CompanyMain',
    data() {
      return {
        companys: [],
      };
    },
    created(){
      fetch("https://localhost:7189/api/company/GetAll")
        .then(response => response.json())
        .then(data => (this.companys = data.data));
    },
    methods: {
      deleteCompany: async function (e) {
        e.preventDefault()
        await fetch(`https://localhost:7189/api/company/${e.target.id}`, {
          method: "DELETE"
          });
          fetch("https://localhost:7189/api/company/GetAll")
        .then(response => response.json())
        .then(data => (this.companys = data.data));
      },
    },
    components: {
    }
}
</script>
