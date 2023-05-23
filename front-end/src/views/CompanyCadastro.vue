<template>
  <main class="content">
    <CadastroCompany/>
  </main>
</template>

<script>
import CadastroCompany from '../components/Cadastro-Company.vue'

export default {
  name: 'App',
  components: {
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
