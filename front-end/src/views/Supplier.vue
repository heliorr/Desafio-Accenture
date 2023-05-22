<template>
  <main class="content">
    <CadastroSupplier/>
  </main>
</template>

<script>
import CadastroSupplier from '../components/Cadastro-Supplier.vue'

export default {
  name: 'App',
  components: {
    CadastroSupplier
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
