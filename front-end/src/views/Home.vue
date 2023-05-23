<template>
  <main class="content">
      <h2 class="text-3xl text-gray-900 dark:text-white">Bem Vindo</h2>
      <article class="text-justify max-w-xl">
        <p>Bem-vindo ao nosso inovador site de cadastro empresarial, onde você pode conectar sua empresa a fornecedores confiáveis de forma eficiente e prática. </p>
        <h4>Conectando empresas e fornecedores:</h4>
        <p>Nosso site foi projetado para simplificar o processo de busca e seleção de fornecedores, permitindo que empresas de diversos setores encontrem parceiros comerciais adequados às suas necessidades e ao cadastrar sua empresa em nossa plataforma, você terá acesso a um amplo diretório de fornecedores.</p>
        <router-link to="/company" class="flex items-center"><p class="mr-4">Inicie agora</p><img class="w-5 animate-bounce" src="../assets/arrow_down.png" alt="Seta para entrar no sistema"></router-link> 
      </article>
      
  </main>
</template>

<script>

export default {
  name: 'App',
  components: {
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
