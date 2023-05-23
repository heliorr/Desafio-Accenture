<template>
  <main class="content">
    <CadastroSuplier/>
  </main>
</template>

<script>
import CadastroSuplier from '../components/Cadastro-Suplier.vue'

export default {
  name: 'App',
  components: {
    CadastroSuplier
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
