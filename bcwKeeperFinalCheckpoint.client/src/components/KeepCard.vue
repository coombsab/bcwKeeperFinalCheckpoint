<template>
  <section class="keep-card mb-3 elevation-3" @click="openModal()">
    <img :src="keep.img" :alt="keep.name" class="img-fluid" data-toggle="modal" data-target="#keepDetailsModal">

  </section>
</template>

<script>
import { Modal } from "bootstrap";
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService";
import KeepDetailsModal from "./KeepDetailsModal.vue";
export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup(props) {
    return {
      async setActiveKeep() {
        await keepsService.setActiveKeep(props.keep.id)
      },
      openModal() {
        this.setActiveKeep()
        let modal = document.getElementById(`keepDetailsModal`)
        let body = document.querySelector("body")
        body.style.overflow = "hidden"
        modal.style.display = "block"
      }
    };
  },
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
    transform: scale(1.03);
    filter: brightness(0.85);
  }
}
</style>