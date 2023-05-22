import { createRouter, createWebHistory } from 'vue-router';
import Company from '../views/Company.vue'
import Supplier from '../views/Supplier.vue'

const routes = [
  { path: '/company', component: Company },
  { path: '/supplier', component: Supplier },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router;
