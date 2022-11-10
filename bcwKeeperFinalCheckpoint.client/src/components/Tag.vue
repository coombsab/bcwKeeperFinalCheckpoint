<template>
  <span class="tag px-2 py-1 m-1 rounded">{{ tag }}</span>
</template>

<script>
export default {
  props: {
    tag: { type: String, required: true }
  },
  setup() {

    return {

    }
  }
}
</script>

<style scoped lang="scss">
.tag {
  // font-family: 'Marko One', serif;
  background-color: #ddd5e0;
  color: black;
  font-size: 12px;
  line-height: 16px;
  text-align: center;
  text-transform: lowercase;
}
</style>