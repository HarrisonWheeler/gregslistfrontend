<template>
  <div class="car">
    <div v-if="car.make">
      <h1>{{car.make}}</h1>
      <img :src="car.imgUrl" alt />
      <button class="btn btn-warning" @click="addToFavorites()">Favorite</button>
    </div>
    <h1 v-else>Loading...</h1>
  </div>
</template>

<script>
export default {
  name: "car",
  mounted() {
    this.$store.dispatch("getActiveCar", this.$route.params.carId);
  },
  computed: {
    car() {
      return this.$store.state.activeCar;
    },
  },
  methods: {
    addToFavorites() {
      let favoriteCar = {
        carId: this.car.id,
      };
      this.$store.dispatch("addToFavorites", favoriteCar);
    },
  },
};
</script>
