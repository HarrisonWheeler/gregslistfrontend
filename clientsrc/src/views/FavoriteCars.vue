<template>
  <div class="favorite-cars row">
    <div v-for="car in cars" class="col-3" :key="car.id">
      <h1>{{car.make}}</h1>
      <h1>{{car.model}}</h1>
      <h1>{{car.year}}</h1>
      <h1>{{car.price}}</h1>
      <h1>{{car.description}}</h1>
      <img class="img-fluid" :src="car.imgUrl" alt />
    </div>
  </div>
</template>


<script>
export default {
  name: "favorite-cars",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getFavoriteCars");
  },
  computed: {
    cars() {
      // NOTE this could also be favoriteCars, we can reuse this property.
      return this.$store.state.cars;
    },
  },
  methods: {},
  components: {},
};
</script>


<style lang="scss" scoped>
</style>