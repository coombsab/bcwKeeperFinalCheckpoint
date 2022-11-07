<template>
  <router-link :to="{ name: 'Vault', params: { vaultId: vault.id }}">
    <section class="vault-card mb-3 d-flex flex-column justify-content-end pos-relative elevation-3" :style="{ backgroundImage: `url(${vault.img})`}">
      <div class="text-visible px-1 title">
        <span>{{vault.name}}</span>
      </div>
      <img src="../assets/img/private-edited.png" alt="private" class="private-img" v-if="vault.isPrivate">
    </section>
  </router-link>
</template>

<script>
import { Vault } from "../models/Vault";

export default {
  props: {
    vault: { type: Vault, required: true }
  },
  setup() {

    return {

    }
  }
}
</script>

<style scoped lang="scss">
.vault-card {
  font-family: 'Quando', serif;
  height: 8rem;
  width: 12rem;
  background-position: center;
  background-size: cover;
  border-radius: 6.94872px;
  transition: 0.2s linear;
}

.vault-card:hover {
  transform: scale(1.1);
  filter: brightness(0.85);
}

span {
  font-size: 24px;
  text-transform: uppercase;
  line-height: 30px;
}

img {
  height: 22px;
  width: 22px;
}

.pos-relative {
  position: relative;
}

.title {
  width: 85%;
}

.private-img {
  position: absolute;
  right: 3%;
  bottom: 3%;
}
</style>