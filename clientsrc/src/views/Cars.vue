<template>
  <div class="cars">
    WELCOME TO THE Cars!!!
    <form @submit.prevent="addCar">
      <label for>Make</label>
      <input type="text" placeholder="make" v-model="newCar.make" required />
      <label for>Model</label>
      <input type="text" placeholder="model" v-model="newCar.model" />
      <label for>Year</label>
      <input type="number" v-model="newCar.year" />
      <label for>Price</label>
      <input type="number" v-model="newCar.price" />
      <label for>Image</label>
      <input type="text" placeholder="Image url" v-model="newCar.imgUrl" />
      <label for>Description</label>
      <input type="text" placeholder="description" v-model="newCar.description" />
      <button class="btn btn-primary btn-sm" type="submit">Create Car</button>
    </form>
    <div v-for="car in cars" :key="car.id">
      <router-link :to="{name: 'car', params: {carId: car.id}}">{{car.make}} - {{car.model}}</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "cars",
  mounted() {
    this.$store.dispatch("getCars");
  },
  data() {
    return {
      newCar: {},
    };
  },
  computed: {
    cars() {
      return this.$store.state.cars;
    },
  },
  methods: {
    addCar() {
      this.newCar.year = +this.newCar.year;
      this.newCar.price = +this.newCar.price;
      this.$store.dispatch("addCar", this.newCar);
      this.newCar = {};
    },
  },
};
</script>