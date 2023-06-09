import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue'
import Company from '../views/Company.vue'
import CompanyCadastro from '../views/CompanyCadastro.vue'
import Suplier from '../views/Suplier.vue'
import SuplierCadastro from '../views/SuplierCadastro.vue'

const routes = [
  { path: '/', component: Home },
  { path: '/company', component: Company },
  { path: '/company/cadastro', component: CompanyCadastro },
  { path: '/suplier', component: Suplier },
  { path: '/suplier/cadastro', component: SuplierCadastro },
  { path: '/detailSuplier', component: Company },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router;
