using UnityEngine;
using UnityEngine.UI;

namespace JellySmash.Extensions
{
    public class FlexibleGridLayout : GridLayoutGroup
    {
        private int _row;
        private int _column;

        public void Init(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public override void SetLayoutHorizontal()
        {
            UpdateCellSize();
            base.SetLayoutHorizontal();
        }

        public override void SetLayoutVertical()
        {
            UpdateCellSize();
            base.SetLayoutVertical();
        }

        private void UpdateCellSize()
        {
            float x = (rectTransform.rect.size.x - padding.horizontal - spacing.x * (_column - 1)) / _column;
            float y = (rectTransform.rect.size.y - padding.vertical - spacing.y * (_row - 1)) / _row;
            int square_size = Mathf.FloorToInt(Mathf.Min(x, y));
            this.constraint = Constraint.FixedColumnCount;
            this.constraintCount = _column;
            this.cellSize = Vector2.one * square_size;
        }
    }
}