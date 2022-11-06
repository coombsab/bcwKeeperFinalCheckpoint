<template>
  <!-- <section class="keep-card" :style="{ backgroundImage: `url('${keep.img}')`}"> -->
  <section class="keep-card mb-3 elevation-3">
    <img :src="keep.img" :alt="keep.name" class="img-fluid">
  </section>
</template>

<script>
import { Keep } from "../models/Keep.js";
export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {

    return {

    }
  }
}
</script>

<style scoped lang="scss">
.keep-card {
  background-position: center;
  background-size: cover;
  width: 100%;
  border-radius: 6.94872px;
}

.keep-card:hover {
  cursor: pointer;
}

img {
  border-radius: 6.94872px;
}

@media screen and (min-width: 768px) {
  .keep-card {
    transition: 0.15s linear;
  }

  .keep-card:hover {
    transform: scale(1.05);
  }
}
</style>