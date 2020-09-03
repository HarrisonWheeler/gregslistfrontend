<template>
  <div class="favorite-jobs row">
    <div v-for="job in jobs" class="col-3" :key="job.id">
      <h1>{{}}</h1>
      <h1>{{}}</h1>
      <h1>{{}}</h1>
      <h1>{{}}</h1>
      <h1>{{}}</h1>
      <img class="img-fluid" :src="car.imgUrl" alt />
    </div>
  </div>
</template>


<script>
export default {
  name: "favorite-jobs",
  data() {
    return {};
  },
  mounted() {
    // this.$store.dispatch("getFavoriteJobs");
  },
  computed: {
    cars() {
      // NOTE this could also be favoriteCars, we can reuse this property.
      // return this.$store.state.cars;
    },
  },
  methods: {},
  components: {},
};
</script>


<style lang="scss" scoped>
</style>