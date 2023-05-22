<template>
    <header>
        <h3>Empresa</h3>
            <section>
                <router-link to="/company">Cadastro Empresa</router-link>
                <router-link to="/supplier">Cadastro Fornecedor</router-link>
            </section>
    </header>
</template>

<style>
    header {
        display: flex;
        flex-grow: 3;
        justify-content: space-between;
    }
    h3 {
        width: 70%;
    }
    section {
        width: 30%;
        display: flex;
        justify-content: space-between;
    }
</style>