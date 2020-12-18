<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
        <a-form-model-item label="书籍ID" prop="BookId">
          <a-input v-model="entity.BookId" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="序号" prop="SerialNums">
          <a-input v-model="entity.SerialNums" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="章节名称" prop="Name">
          <a-input v-model="entity.Name" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="章节字数" prop="WordNums">
          <a-input v-model="entity.WordNums" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="下载状态 1：已下载 0未下载" prop="Status">
          <a-input v-model="entity.Status" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="书籍下载地址" prop="Url">
          <a-input v-model="entity.Url" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="AddTime" prop="AddTime">
          <a-input v-model="entity.AddTime" autocomplete="off" />
        </a-form-model-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
export default {
  props: {
    parentObj: Object
  },
  data() {
    return {
      layout: {
        labelCol: { span: 5 },
        wrapperCol: { span: 18 }
      },
      visible: false,
      loading: false,
      entity: {},
      rules: {},
      title: ''
    }
  },
  methods: {
    init() {
      this.visible = true
      this.entity = {}
      this.$nextTick(() => {
        this.$refs['form'].clearValidate()
      })
    },
    openForm(id, title) {
      this.init()

      if (id) {
        this.loading = true
        this.$http.post('/EBook/Chapter/GetTheData', { id: id }).then(resJson => {
          this.loading = false

          this.entity = resJson.Data
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/EBook/Chapter/SaveData', this.entity).then(resJson => {
          this.loading = false

          if (resJson.Success) {
            this.$message.success('操作成功!')
            this.visible = false

            this.parentObj.getDataList()
          } else {
            this.$message.error(resJson.Msg)
          }
        })
      })
    }
  }
}
</script>
