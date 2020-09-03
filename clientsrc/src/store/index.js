import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from '../router/index'

Vue.use(Vuex)

//Allows axios to work locally or live
let base = window.location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: base + "api/",
  timeout: 3000,
})

export default new Vuex.Store({
  state: {
    user: {},
    cars: [],
    activeCar: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setCars(state, cars) {
      state.cars = cars
    },
    setActiveCar(state, car) {
      state.activeCar = car
    }
  },
  actions: {
    //#region -- AUTH STUFF --
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    //#endregion


    //#region -- BOARDS --
    getCars({ commit }) {
      api.get('cars')
        .then(res => {
          commit('setCars', res.data)
        })
    },
    async addCar({ dispatch }, carData) {
      try {
        let res = await api.post('cars', carData)
        dispatch("getCars")
      } catch (error) {
        console.error(error)
      }
    },
    async getActiveCar({ commit }, carId) {
      try {
        let res = await api.get("cars/" + carId)
        commit("setActiveCar", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async addToFavorites({ commit, dispatch }, favoriteCar) {
      try {
        let res = await api.post("favoriteCars", favoriteCar)
        console.log(res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getFavoriteCars({ commit }) {
      try {
        let res = await api.get("favoriteCars")
        commit("setCars", res.data)
      } catch (error) {
        console.error(error);
      }
    }
    //#endregion


    //#region -- LISTS --



    //#endregion
  }
})
