<template>
  <section class="account text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </section>
  <h1>Vaults</h1>
  <section class="vaults gap-3">
    <VaultCard v-for="v in myVaults" :key="v.id" :vault="v" />
  </section>
  <h1>Keeps</h1>
  <section class="keeps p-3">
    <KeepCard v-for="k in myKeeps" :key="k.id" :keep="k" />
  </section>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import KeepCard from "../components/KeepCard.vue"
import VaultCard from "../components/VaultCard.vue"
export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      myVaults: computed(() => AppState.myVaults),
      myKeeps: computed(() => AppState.myKeeps)
    };
  },
  components: { KeepCard, VaultCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.vaults {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-evenly;
}

.keeps {
  columns: 2;
}

@media screen and (min-width: 768px) {
  .keeps {
    columns: 4;
  }
}
</style>
