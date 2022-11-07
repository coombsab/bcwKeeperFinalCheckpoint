<template>
  <section class="account text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </section>
  <section class="vaults">
    
  </section>
  <section class="keeps p-3">
    <KeepCard v-for="k in myKeeps" :key="k.id" :keep="k" />
  </section>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import KeepCard from "../components/KeepCard.vue"
import { keepsService } from "../services/KeepsService"
import Pop from "../utils/Pop"
export default {
    setup() {
        async function getMyKeeps() {
            try {
                await keepsService.getKeepsByProfileId(AppState.account.id);
            }
            catch (error) {
                Pop.error(error.message, "[function]");
            }
        }
        onMounted(() => {
            getMyKeeps();
        });
        return {
            account: computed(() => AppState.account),
            myVaults: computed(() => AppState.myVaults),
            myKeeps: computed(() => AppState.keeps)
        };
    },
    components: { KeepCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
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
