import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Cars from '../views/Cars.vue'
import FavoriteCars from '../views/FavoriteCars.vue'
import FavoriteJobs from '../views/FavoriteJobs.vue'
import Car from '../views/Car.vue'
import { authGuard } from "@bcwdev/auth0-vue"

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/cars',
      name: 'cars',
      component: Cars,
      beforeEnter: authGuard
    },
    {
      path: '/mycars',
      name: 'mycars',
      component: FavoriteCars,
      beforeEnter: authGuard
    },
    {
      path: '/myjobs',
      name: 'myjobs',
      component: FavoriteJobs,
      beforeEnter: authGuard
    },
    {
      path: '/cars/:carId',
      name: 'car',
      component: Car
    },
    {
      path: "*",
      redirect: '/'
    }
  ]
})