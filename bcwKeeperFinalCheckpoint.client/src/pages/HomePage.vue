<template>
  <div class="home p-3 h-80" v-if="keeps.length > 0">
    <KeepCard v-for="k in keeps" :key="k.id" :keep="k" />
  </div>
  <div class="d-flex flex-column h-80 pos-relative" v-else>
    <span class="fadeIn m-auto fs-1 fw-700">Could not find any keeps.  Try reloading the page or adding some!</span>
    <Spinner />
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState";
import KeepCard from "../components/KeepCard.vue";
import Tag from "../components/Tag.vue";
import { keepsService } from "../services/KeepsService";
import Pop from "../utils/Pop";

export default {
  setup() {
    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      }
      catch (error) {
        Pop.error(error.message, "[getKeeps]")
      }
    }

    onMounted(() => {
      getKeeps()
    })
    return {
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { Tag, KeepCard }
}
</script>

<style scoped lang="scss">
.home {
  columns: 2;
}

@media screen and (min-width: 768px) {
  .home {
    columns: 4;
  }
}
</style>
