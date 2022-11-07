<template>
  <section class="keep-card mb-3 elevation-3 pos-relative">
    <div class="keep-card-wrapper pos-relative" @click="openModal()">
      <img :src="keep.img" :alt="keep.name" class="img-fluid" data-toggle="modal" data-target="#keepDetailsModal">
      <span class="text-visible keep-label m-3">{{keep.name}}</span>
    </div>
    <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
      <img :src="keep.creator.picture" :alt="keep.creator.name" :title="keep.creator.name" class="profile-img selectable m-3">
    </router-link>
  </section>
</template>

<script>
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService";

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

.keep-card-wrapper {
  height: 100%;
  width: 100%;
}

.keep-card-wrapper:hover {
  cursor: pointer;
}

img {
  border-radius: 6.94872px;
}

.profile-img {
  display: none;
}

.pos-relative {
  position: relative;
}

.keep-label {
  position: absolute;
  bottom: 10px;
  left: 0;
  width: 90%;
}

@media screen and (min-width: 768px) {
  .keep-card {
    transition: 0.15s linear;
  }
  
  .keep-card-wrapper:hover {
    transform: scale(1.03);
    filter: brightness(0.85);
  }

  .profile-img {
    display: block;
    border-radius: 50%;
    height: 40px;
    width: 40px;
    position: absolute;
    right: 0;
    bottom: 0;
  }
}
</style>