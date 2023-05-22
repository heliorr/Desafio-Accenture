<template>
    <form>
        <label for="cnpjCpf">
            CNPJ ou CPF:
            <input type="text" name="cnpjCpf" id="cnpjCpf" key="cnpjCpf">
        </label>
        <label for="rg">
            RG:
            <input type="text" name="rg" id="rg" key="rg">
        </label>
        <label for="dateBirth">
            Data de Nascimento:
            <input type="text" name="dateBirth" id="dateBirth" key="dateBirth">
        </label>
        <label for="name">
            Nome:
            <input type="text" name="name" id="name" key="name">
        </label>
        <label for="email">
            E-mail:
            <input type="text" name="email" id="email" key="email">
        </label>
        <label for="cep">
            CEP:
            <input type="text" name="cep" id="cep" key="cep">
        </label>
        <label for="district">
            Bairro:
            <input type="text" name="district" id="district" key="district">
        </label>
        <label for="street">
            Rua:
            <input type="text" name="street" id="street" key="street">
        </label>
        <label for="city">
            Cidade:
            <input type="text" name="city" id="city" key="city">
        </label>
        <label for="residence">
            Numero:
            <input type="text" name="residence" id="residence" key="residence">
        </label>
        <button>Cadastrar</button>
    </form>
</template>

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