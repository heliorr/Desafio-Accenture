<template>
  <HeaderCompany/>
  <main class="content">
    <CadastroCompany/>
  </main>
</template>

<script>
import CadastroCompany from './components/Cadastro-Company.vue'
import HeaderCompany from './components/Header-Company.vue'

export default {
  name: 'App',
  components: {
    HeaderCompany,
    CadastroCompany
  }
}
</script>

<style>
.content {
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
