<template>
    <form>
        <label for="company">
            CNPJ:
            <input type="text" name="CNPJ" id="CNPJ" key="CNPJ">
        </label>
        <label for="company">
            Nome Fantasia:
            <input type="text" name="company" id="company" key="company">
        </label>
        <label for="CEP">
            CEP:
            <input type="text" name="CEP" id="CEP" key="CEP">
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