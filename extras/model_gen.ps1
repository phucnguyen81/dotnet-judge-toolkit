quicktype --src model_schema.json `
    --src-lang schema `
    --lang cs `
    --out src/JudgeModel.cs `
    --namespace Judge.Model `
    --top-level JudgeModel `
    --csharp-version 6
