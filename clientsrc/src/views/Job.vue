<template>
  <div class="job">
    <div v-if="job.make">
      <h1>{{job.make}}</h1>
      <img :src="job.imgUrl" alt />
      <button class="btn btn-warning" @click="addToFavorites()">Favorite</button>
    </div>
    <h1 v-else>Loading...</h1>
  </div>
</template>

<script>
export default {
  name: "job",
  mounted() {
    this.$store.dispatch("getActiveCar", this.$route.params.carId);
  },
  computed: {
    job() {
      return this.$store.state.activeCar;
    },
  },
  methods: {
    addToFavorites() {
      let favoriteCar = {
        carId: this.job.id,
      };
      this.$store.dispatch("addToFavorites", favoriteCar);
    },
  },
};
</script>
